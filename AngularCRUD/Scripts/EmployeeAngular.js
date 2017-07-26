var app = angular.module("myApp", []);
app.controller("myCtrl", function ($scope, $http) {
    debugger;
    $scope.InsertData = function () {
        var Action = document.getElementById("btnSave").getAttribute("value");
        if (Action == "Submit") {
            $scope.Employe = {};
            $scope.Employe.Name = $scope.Name;
            $scope.Employe.City = $scope.City;
            $scope.Employe.Gender = $scope.Gender;
            $scope.Employe.Salary = $scope.Salary;
            $scope.Employe.DateofBirth = $scope.DateofBirth;
            $http({
                method: "post",
                url: "http://localhost:60912/Employee/Insert_Employee",
                datatype: "json",
                data: JSON.stringify($scope.Employe)
            }).then(function (response) {
                alert(response.data);
                $scope.GetAllData();
                $scope.Name = "";
                $scope.City = "";
                $scope.Gender = "";
                $scope.Salary = "";
            })
        } else {
            $scope.Employe = {};
            $scope.Employe.Name = $scope.Name;
            $scope.Employe.City = $scope.City;
            $scope.Employe.Gender = $scope.Gender;
            $scope.Employe.Salary = $scope.Salary;
            $scope.Employe.DateofBirth = $scope.DateofBirth;
            $scope.Employe.Id = document.getElementById("EmpID_").value;
            $http({
                method: "post",
                url: "http://localhost:60912/Employee/Update_Employee",
                datatype: "json",
                data: JSON.stringify($scope.Employe)
            }).then(function (response) {
                alert(response.data);
                $scope.GetAllData();
                $scope.Name = "";
                $scope.City = "";
                $scope.Gender = "";
                $scope.Salary = "";
                $scope.DateofBirth = "";
                document.getElementById("btnSave").setAttribute("value", "Submit");
                document.getElementById("btnSave").style.backgroundColor = "cornflowerblue";
                document.getElementById("spn").innerHTML = "Add New Employee";
            })
        }
    }
    $scope.GetAllData = function () {
        $http({
            method: "get",
            url: "http://localhost:60912/Employee/Get_AllEmployee"
        }).then(function (response) {
            $scope.employees = response.data;
        }, function () {
            alert("Error Occur");
        })
    };
    $scope.DeleteEmp = function (Emp) {
        $http({
            method: "post",
            url: "http://localhost:60912/Employee/Delete_Employee",
            datatype: "json",
            data: JSON.stringify(Emp)
        }).then(function (response) {
            alert(response.data);
            $scope.GetAllData();
        })
    };
    $scope.UpdateEmp = function (Emp) {
        document.getElementById("EmpID_").value = Emp.Id;
        $scope.Name = Emp.Name;
        $scope.City = Emp.City;
        $scope.Gender = Emp.Gender;
        $scope.Salary = Emp.Salary;
        $scope.DateofBirth = Emp.DateofBirth;
        document.getElementById("btnSave").setAttribute("value", "Update");
        document.getElementById("btnSave").style.backgroundColor = "Yellow";
        document.getElementById("spn").innerHTML = "Update Employee Information";
    }
})