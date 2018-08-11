$(function () {

    // Add login formulaire
    var basicAuthUI = [
        '<div class="input">',
        '<input placeholder="username" id="input_username" name="username" type="text" size="10">',
        '</div>',
        '<div class="input">',
        '<input placeholder="password" id="input_password" name="password" type="password" size="10">',
        '</div>',//
        '<div class="input">',//
        '<input placeholder="Scope" id="input_scope" name="Scope" type="text" size="10" value="DITRA">',//
        '</div>'//
    ].join("\n");
    $(basicAuthUI).insertBefore('#api_selector div.input:last-child');
    $("#input_apiKey").hide();

    // On login formulaire change
    $("#input_username, #input_password, #input_scope").change(function () {

        // Get login information
        var username = ($('#input_username').val() || "").trim();
        var password = ($('#input_password').val() || "").trim();
        var Scope = ($('#input_scope').val() || "").trim();//

        if (username == "" || password == "")
            return;

        // Get token
        $.ajax({
            type: "POST",
            url: swaggerUi.api.scheme + "://" + swaggerUi.api.host + "/token",
            data: {
                grant_type: "password",
                username: username,
                password: password,//
                Scope: Scope//
            },
            success: function (data, textStatus, jqXHR) {
                $("#input_password")
                    .css('color', 'green')
                    .css('border', '1px solid green');

                // Add token to header
                var authorization = data.token_type + " " + data.access_token;
                console.log("Authorization", authorization);

                swaggerUi.api.clientAuthorizations.add("oauth2",
                    new SwaggerClient.ApiKeyAuthorization("Authorization", authorization, "header"));
            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.error("token error", jqXHR, textStatus, errorThrown);

                $("#input_password")
                    .css('color', 'red')
                    .css('border', '1px solid red');
            },
            dataType: "json"
        });
    });
});