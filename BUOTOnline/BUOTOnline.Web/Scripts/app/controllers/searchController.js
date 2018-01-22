app.controller('searchController', ['$scope', '$http', function ($scope, $http) {
    $scope.getLowestCategories = function () {
        $http.get('/api/lowestCategories').then(function (result) {
            $scope.categories = result.data;
        });
    }

    $scope.getChildrenCategories = function (currentCategoryId) {
        $http.get('/api/childrenCategories/' + currentCategoryId).then(function (result) {
            $scope.categories = result.data;
        });
    };

    $scope.select = function () {
        if ($scope.chosenCategory) {
            $('#categoryId').val($scope.chosenCategory.id);

            $('#CategoryForm').submit();
        }
    };
}]);