app.controller('adminController', function ($scope, $http) {
    $scope.test = 'test';

    $http.get('/api/test').then(function (result) {
        $scope.test = result.data;
    });

    $scope.getInheritedAttributes = function () {
        console.log($scope.parentId);
    }

    $scope.attrs = [1, 2, 3];
});