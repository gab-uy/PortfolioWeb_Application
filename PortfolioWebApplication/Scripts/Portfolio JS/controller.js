// Get the existing module
var app = angular.module("PortfolioWebApplication");

// Register the contact controller
app.controller("contactCtrl", ['$scope', '$timeout', 'PortfolioWebApplicationService',
    function ($scope, $timeout, PortfolioWebApplicationService) {

        $scope.multiarray = []; //multiarray
        $scope.submitted = false;
        $scope.formData = {};
        $scope.errors = {};
        //$scope.registrationData = []; //archiving

        // --- FORM VALIDATION ---
        function validateForm(form) {
            var isValid = true;
            $scope.errors = {}; // reset errors

            // Name
            if (!$scope.formData.name || $scope.formData.name.trim() === "") {
                $scope.errors.name = "Name is required.";
                isValid = false;
            } else if ($scope.formData.name.length < 2) {
                $scope.errors.name = "Name must be at least 2 characters.";
                isValid = false;
            } else if ($scope.formData.name.length > 30) {
                $scope.errors.name = "Name cannot exceed 30 characters.";
                isValid = false;
            } else if (!/^[A-Za-z\s'-]+$/.test($scope.formData.name)) {
                $scope.errors.name = "Only letters, spaces, apostrophes, and hyphens allowed.";
                isValid = false;
            }

            // Phone
            if (!$scope.formData.phone || $scope.formData.phone.trim() === "") {
                $scope.errors.phone = "Phone is required.";
                isValid = false;
            } else if (!/^\+?[0-9]{10,15}$/.test($scope.formData.phone)) {
                $scope.errors.phone = "Phone must be 10–15 digits, optional + at start.";
                isValid = false;
            }

            // Email
            if (!$scope.formData.email || $scope.formData.email.trim() === "") {
                $scope.errors.email = "Email is required.";
                isValid = false;
            } else if (!/^[^\s@]+@[^\s@]+\.[^\s@]+$/.test($scope.formData.email)) {
                $scope.errors.email = "Enter a valid email.";
                isValid = false;
            }

            // Subject
            if (!$scope.formData.subject) {
                $scope.errors.subject = "Please select a subject.";
                isValid = false;
            }

            // Message
            if (!$scope.formData.message || $scope.formData.message.trim() === "") {
                $scope.errors.message = "Message is required.";
                isValid = false;
            } else if ($scope.formData.message.length < 10) {
                $scope.errors.message = "Message must be at least 10 characters.";
                isValid = false;
            } else if ($scope.formData.message.length > 1000) {
                $scope.errors.message = "Message cannot exceed 1000 characters.";
                isValid = false;
            }

            return isValid;
        }

        // --- SUBMIT FORM ---
        $scope.submitForm = function (form, $event) {
            console.log("Entered submit form function");
            if ($event) $event.preventDefault();
            form.$setSubmitted();

            if (!validateForm(form)) return;

            var userInfo = angular.copy($scope.formData);

            PortfolioWebApplicationService.jsonService(userInfo)
                .then(function (response) {

                    console.log(response);
                    console.log("response data: ",response.data);

                    $scope.multiarray.push(userInfo);
                    $scope.formData = {};
                    $scope.errors = {};
                    $scope.submitted = true;

                    form.$setPristine();
                    form.$setUntouched();

                    // Hide success message after 3 seconds
                    $timeout(function () {
                        $scope.submitted = false;
                    }, 3000);
                })
                .catch(function (error) {
                    console.error(error);
                    alert("Error submitting data. Please try again.");
                });
        };

        // --- TEST / BACKEND FUNCTIONS ---
        $scope.connect = function () {
            PortfolioWebApplicationService.connectivity()
                .then(function (response) {
                    alert(response.data);
                });
        };

        $scope.parameterConnect = function () {
            PortfolioWebApplicationService.parameterConnect($scope.formData.name)
                .then(function (response) {
                    alert(response.data);
                });
        };

        $scope.collectiveParameter = function () {
            PortfolioWebApplicationService.collectiveConnect($scope.formData)
                .then(function (response) {
                    alert(response.data);
                });
        };

        $scope.redirecttoSecondPage = function () {
            window.location.href = "/Main/SecondPage";
        };


        /*/ARCHIVING SCOPE
        $scope.getRegistration = function () {
            var getData = PortfolioWebApplicationService.getRegistrationService();
            getData.then(function (returnedData) {
                $scope.registrationData = returnedData.data
            }*/

        
    }]);