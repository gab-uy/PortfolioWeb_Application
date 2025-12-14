var app = angular.module("PortfolioWebApplication");

app.service("PortfolioWebApplicationService", function ($http) {

    // Option 1: Simple GET request
    this.connectivity = function () {
        return $http.get("/PortfolioWebApplication/ConcatenateFunc");
    };

    /*/ Option 1 VARIATION for archiving
    this.getRegistrationService = function () {
        return $http.get("/PortfolioWebApplication/GetRegistration");
    }*/

    // Option 2: POST request with parameter
    this.parameterConnect = function (name) {
        return $http({
            method: "POST",
            url: "/PortfolioWebApplication/ParameterConcatenate",
            params: {
                name: name
            }
        });
    };

    // Option 3: POST request to submit JSON data
    this.jsonService = function (userData) {
        return $http({
            method: "POST",
            url: "/PortfolioWebApplication/Upsert",
            data: userData
        });
    };

    // Option 4: POST request to send a user object (if needed)
    this.collectiveConnect = function (userInfo) {
        return $http({
            method: "POST",
            url: "/PortfolioWebApplication/CollectiveUpsert",
            data: userInfo
            //headers: { "Content-Type": "application/json" }
        });
    };

});