ezmoveapp.controller('employeecontroller', ['$scope', employeecontroller]);

function employeecontroller($scope) {
    $scope.users = [
    {
        firstname: "Raghu",
        lastname: "Nedunuri",
        email: "raghu.nedunuri@gmail.com"
    },
    {
        firstname: "Srinivas",
        lastname: "Mundru",
        email: "srinivas.mundru@gmail.com"
    },
    {
        firstname: "Ayyappa",
        lastname: "Yellapu",
        email: "ayyappa.yellapu@gmail.com"
    }
    ]

    $scope.checkName = function (data, id) {       
    };

    $scope.saveUser = function (data, id) {
        //$scope.user not updated yet       
        angular.extend(data, { id: id });
        return $http.post('/saveUser', data);
    };

    // remove user
    $scope.removeUser = function (index) {        
        $scope.users.splice(index, 1);
    };

}