app.controller('editCategoryController', ['$scope', '$http', function ($scope, $http) {
    $scope.attributes = JSON.parse($('#Content').val());

    $scope.states = ['new', 'old'];

    $scope.sizes = ['s', 'm', 'l'];

    $http.get('/api/states').then(function (result) {
        $scope.states = result.data;
    });

    $http.get('/api/sizes').then(function (result) {
        $scope.sizes = result.data;
    });

    $scope.submit = function () {
        $('#Content').val(JSON.stringify($scope.attributes));

        $('#Form').submit();
    }
}]);