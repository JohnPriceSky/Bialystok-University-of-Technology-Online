app.controller('noticeController', function ($scope, $http) {
    $scope.attributes = JSON.parse($('#Content').val());
});