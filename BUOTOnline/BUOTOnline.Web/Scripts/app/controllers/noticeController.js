app.controller('noticeController', ['$scope', '$http', function ($scope, $http) {
    $scope.attributes = JSON.parse($('#Content').val());
}]);