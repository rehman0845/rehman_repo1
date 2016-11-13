var app = angular.module("myapp", ["ngRoute"]);
app.service("Service", Service);

app.controller("divctrl", function ($scope, $http, Service) {

    $scope.student = {};
    $scope.insert = function () {
        $scope.clear();
        $scope.showdiv = true;
        $scope.show = true;
    }

    $scope.create = function () {

        var data = {
            sno: $scope.student.sno,
            sname: $scope.student.sname,
            course: $scope.student.course,
            fee: $scope.student.fee
        }

        var request = Service.CreateStudent(data);
        request.then(function (response) {
            console.log(response.data)
            $scope.SelectAll();
            $scope.DropdownItems();
        },
        function (error) { console.log(error) });
        $scope.clear();
        $scope.showdiv = false;

    }

    $scope.List = {};

    $scope.SelectAll = function () {
        $http.get("http://localhost:49500/Student1/GetAll")
          .then(function (response) {
              $scope.List = response.data;
          },
          function (error) { console.log(error) });
    }

    $scope.SelectAll();

    $scope.DropdownList = [];
    $scope.DropdownItems = function () {
        $http.get("http://localhost:49500/Student1/CourseList")
            .then(function (response) {
                $scope.DropdownList = response.data;
            },
            function (error) { console.log(error) });
    }

    $scope.DropdownItems();

    $scope.Edit = function (st) {
        $scope.showdiv = true;
        $scope.show = false;
        var sno = st.sno;
        $http.get("http://localhost:49500/Student1/Edit?sno=" + sno)
            .then(function (response) {
                $scope.student.sno = response.data.sno;
                $scope.student.sname = response.data.sname;
                $scope.student.course = response.data.course;
                $scope.student.fee = response.data.fee;
            },
            function (error) { console.log(error) });
    }

    $scope.Update = function () {
        var data = {
            sno: $scope.student.sno,
            sname: $scope.student.sname,
            course: $scope.student.course,
            fee: $scope.student.fee
        }
        $http.post("http://localhost:49500/Student1/Update", data)
            .then(function (response) {
                console.log(response.data);
                $scope.SelectAll();
                $scope.DropdownItems();
            },
            function (error) { console.log(error) });
        $scope.clear();
        $scope.showdiv = false;
    }

    $scope.Delete = function (st) {
        $http.post("http://localhost:49500/Student1/Remove", st)
            .then(function (response) {
                console.log(response.data);
                $scope.SelectAll();
                $scope.DropdownItems();
            },
            function (error) { console.log(error) });
    }

    $scope.clear = function () {
        $scope.student.sno = "";
        $scope.student.sname = "";
        $scope.student.course = "";
        $scope.student.fee = "";
    }

    $scope.SelectedItem = function () {
        var str = $scope.Selecteditem;
        console.log($scope.Selecteditem);
        $http.get("http://localhost:49500/Student1/SearchItem?str=" + str)
            .then(function (response) {
                console.log(response.data);
                $scope.List = response.data;
            });
    }

    $scope.SearchItem = function () {

        $("#search").autocomplete({
            source: $scope.DropdownList
        });
    }
});//controller
app.directive("fillDropDown", function () {
    return {
        restrict: 'E',
        template: "<select id='kk' ng-model='Selecteditem' ng-change='SelectedItem()'></select>",
        link: function (scope, element, attr) {
            console.log(scope);
            console.log(element);
            console.log(attr);

            scope.$watch(attr.source, function (nv, ov) {
                console.log(attr.source);
                $("#kk").empty();
                for (i = 0; i < scope.DropdownList.length + 1; i++) {
                    if (i == 0)
                        element.children().append($("<option/>", { value: "", text: "" }));
                    else
                        element.children().append($("<option/>", { value: scope.DropdownList[i - 1], text: scope.DropdownList[i - 1] }));
                }
            });
        }
    }
});
