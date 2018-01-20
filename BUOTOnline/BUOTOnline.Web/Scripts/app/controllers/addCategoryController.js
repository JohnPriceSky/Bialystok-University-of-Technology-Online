app.controller('addCategoryController', function ($scope, $http) {
    $scope.imageUrl = 'https://www.image.ie/images/no-image.png';
    $scope.addedCategories = [];
    $scope.attributes = [];

    $http.get('/api/categories').then(function (result) {
        $scope.categories = result.data;
    });

    function getAttributes(categoryId) {
        $http.get('/api/category/attributes/' + categoryId).then(function (result) {
            for (i = 0; i < result.data.length; i++) {
                var isAlreadyIn = false;
                for (j = 0; j < $scope.attributes.length; j++)
                    if (result.data[i].id === $scope.attributes[j].id)
                        isAlreadyIn = true;

                if (!isAlreadyIn)
                    $scope.attributes.push(result.data[i]);
            }
        });
    }

    $scope.addCategory = function () {
        if ($scope.addedCategory) {
            for (i = 0; i < $scope.addedCategories.length; i++)
                if ($scope.addedCategories[i].id === $scope.addedCategory.id)
                    return

            if ($scope.addedCategory.id > 0) {
                getAttributes($scope.addedCategory.id)
            }

            $scope.addedCategories.push($scope.addedCategory);
        }
    };

    $scope.removeCategory = function (category) {
        var index = $scope.addedCategories.indexOf(category);
        if (index > -1) {
            $scope.addedCategories.splice(index, 1);

            $scope.attributes = [];
            for (i = 0; i < $scope.addedCategories.length; i++)
                getAttributes($scope.addedCategories[i].id);
        }
    };

    $scope.submit = function () {
        var categoriesIds = [];
        for (i = 0; i < $scope.addedCategories.length; i++)
            categoriesIds.push($scope.addedCategories[i].id)

        $('#CategoriesIds').val(String(categoriesIds));

        var content = [];
        for (i = 0; i < $scope.attributes.length; i++)
            content.push({
                type: $scope.attributes[i].type,
                name: $scope.attributes[i].name,
                value: $scope.attributes[i].value
            });

        $('#Content').val(JSON.stringify(content));

        $('#Form').submit();
    }
});