function Service() {
    this.createStudent = function (student) {
        var request = $http({
            method: 'POST',
            url: 'http://localhost:49500/Student1/Insert',
            data: student
        });
        return request;
    }

    this.GetAll = function () {
        var request = $http({
            method: 'GET',
            url: 'http://localhost:49500/Student1/GetAll'
        });
        return request;
    }

    this.EditStudent = function (sno) {
        var request = $http({
            method: 'GET',
            url: 'http://localhost:49500/Student1/Edit?sno='+sno
        });
        return request;
    }

    this.UpdateStudent = function (student) {
        var request = $http({
            method: 'POST',
            url: 'http://localhost:49500/Student1/Update',
            data:student
        });
        return request;
    }

    this.DeleteStudent = function (student) {
        var request = $http({
            method: 'POST',
            url: 'http://localhost:49500/Student1/Remove',
            data: student
        });
        return request;

    }
}