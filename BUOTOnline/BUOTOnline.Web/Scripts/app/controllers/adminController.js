app.controller('adminController', function ($scope, $http) {

    $http.get('/api/attributes').then(function (result) {
        $scope.attributes = result.data;
    });

    $scope.getInheritedAttributes = function () {
        if ($scope.parentId > 0) {
            $http.get('/api/category/attributes/' + $scope.parentId).then(function (result) {
                $scope.inheritedAttributes = result.data;

                if ($scope.addedAttrs) {
                    for (i = 0; i < $scope.addedAttrs.length; i++)
                        for (j = 0; j < $scope.inheritedAttributes.length; j++)
                            if ($scope.addedAttrs[i].id === $scope.inheritedAttributes[j].id) {
                                var index = $scope.addedAttrs.indexOf($scope.addedAttrs[i]);
                                if (index > -1)
                                    $scope.addedAttrs.splice(index, 1);

                                index = $scope.attrs.indexOf($scope.inheritedAttributes[j].id);
                                if (index > -1) {
                                    $scope.attrs.splice(index, 1);

                                    $("#AttributeIds").val(String($scope.attrs));
                                }
                            }
                }
            });
        }
    }

    $scope.addAttribute = function () {

        if ($scope.inheritedAttributes)
            for (i = 0; i < $scope.inheritedAttributes.length; i++)
                if ($scope.inheritedAttributes[i].id === $scope.addedAttr.id)
                    return;

        for (i = 0; i < $scope.addedAttrs.length; i++)
            if ($scope.addedAttrs[i].id === $scope.addedAttr.id)
                return;

        $scope.addedAttrs.push($scope.addedAttr);
        $scope.attrs.push($scope.addedAttr.id);

        $("#AttributeIds").val(String($scope.attrs));
    };

    $scope.removeAttribute = function (attr) {
        var index = $scope.addedAttrs.indexOf(attr);
        if (index > -1) {
            $scope.addedAttrs.splice(index, 1);
        }

        index = $scope.attrs.indexOf(attr.id);
        if (index > -1) {
            $scope.attrs.splice(index, 1);

            $("#AttributeIds").val(String($scope.attrs));
        }
    }

    $scope.addedAttrs = [];
    $scope.attrs = [];
});