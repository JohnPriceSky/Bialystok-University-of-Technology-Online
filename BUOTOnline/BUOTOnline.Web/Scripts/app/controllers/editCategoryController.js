app.controller('editCategoryController', function ($scope, $http) {
    $scope.attributes = JSON.parse($('#Content').val());

    $scope.submit = function () {
        $('#Content').val(JSON.stringify($scope.attributes));

        $('#Form').submit();
    }
});