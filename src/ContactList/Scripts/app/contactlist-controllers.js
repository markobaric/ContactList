ContactListApp.controller('ListController', function ($scope, $rootScope, $location, ContactService) {
    $scope.search = function () {
        ContactService.GetAll($scope.searchText, $scope.sortOrder, $scope.isDesc).then(function (response) {
            $scope.contacts = response.data;
        },
        function (response) {
            $rootScope.error = "Error occured while loading contacts.";
        });
    };

    $scope.sort = function (column) {
        if ($scope.sortOrder === column) {
            $scope.isDesc = !$scope.isDesc;
        }
        else {
            $scope.sortOrder = column;
            $scope.isDesc = false;
        }

        $scope.search();
    };

    $scope.delete = function (contactId) {
        ContactService.Delete(this.contact.Id).then(function (response) {
            $scope.contacts.splice(this.$index, 1);
        },
        function (response) {
            $rootScope.error = "Error occured while deleting contact.";
        });
    };

    $scope.sortOrder = "LastName";
    $scope.isDesc = false;

    $scope.search();
});
ContactListApp.controller('DetailsController', function ($scope, $location, $routeParams, ContactService, PhoneService, EmailService, TagService, EntryTypeService) {
    $scope.phones = [];
    $scope.emails = [];
    $scope.tags = [];

    // If this is edit, load Contact
    if ($routeParams.contactId != undefined) {
        ContactService.GetById($routeParams.contactId).then(function (response) {
            $scope.contact = response.data;
            $scope.phones = $scope.contact.Phones;
            $scope.emails = $scope.contact.Emails;
            $scope.tags = $scope.contact.Tags;
        },
        function (response) {
            $rootScope.error = "Error occured while loading contact.";
        });
    }

    // Preload EntryTypes
    EntryTypeService.GetAll().then(function (response) {
        $scope.entryTypes = response.data;
    },
    function (response) {
        $rootScope.error = "Error occured while loading Entry Types.";
    });

    $scope.save = function () {
        if ($scope.contact.Id === undefined) {
            // INSERT
            ContactService.Insert($scope.contact.FirstName, $scope.contact.LastName, $scope.contact.Address, $scope.phones, $scope.emails, $scope.tags).then(function (response) {
                $location.path('/');
            },
            function (response) {
                $rootScope.error = "Error occured while saving new contact.";
            });
        }
        else {
            // EDIT
            ContactService.Update($scope.contact.Id, $scope.contact.FirstName, $scope.contact.LastName, $scope.contact.Address, $scope.phones, $scope.emails, $scope.tags).then(function (response) {
                $location.path('/');
            },
            function (response) {
                $rootScope.error = "Error occured while updating contact.";
            });
        }
    };

    $scope.addPhone = function () {
        if ($scope.phone.Type == undefined || $scope.phone.Type == null)
            return;

        // Find EntryType by selected name
        var type;
        for (var index = 0; index < $scope.entryTypes.length; ++index) {
            if ($scope.entryTypes[index].Name == $scope.phone.Type)
                type = $scope.entryTypes[index];
        }
        var phone = {
            Number: $scope.phone.Number,
            Type: type
        }
        
        $scope.phones.push(phone);

        $scope.phone.Number = null;
        $scope.phone.Type = null;
    };
    $scope.deletePhone = function (Id) {
        var indexToRemove;
        for (index = 0; index < $scope.phones.length; ++index) {
            if ($scope.phones[index].Id == Id)
                indexToRemove = index;
        }

        $scope.phones.splice(indexToRemove, 1);
    };
    $scope.addEmail = function () {
        if ($scope.email.Type == undefined || $scope.email.Type == null)
            return;

        // Find EntryType by selected name
        var type;
        for (var index = 0; index < $scope.entryTypes.length; ++index) {
            if ($scope.entryTypes[index].Name == $scope.email.Type)
                type = $scope.entryTypes[index];
        }
        var email = {
            Address: $scope.email.Address,
            Type: type
        }

        $scope.emails.push(email);

        $scope.email.Address = null;
        $scope.email.Type = null;
    };
    $scope.deleteEmail = function (Id) {
        var indexToRemove;
        for (index = 0; index < $scope.emails.length; ++index) {
            if ($scope.emails[index].Id == Id)
                indexToRemove = index;
        }

        $scope.emails.splice(indexToRemove, 1);
    };
    $scope.addTag = function () {
        var tag = {
            Text: $scope.tag.Text
        }

        $scope.tags.push(tag);

        $scope.tag.Text = null;
    };
    $scope.deleteTag = function (Id) {
        var indexToRemove;
        for (index = 0; index < $scope.tags.length; ++index) {
            if ($scope.tags[index].Id == Id)
                indexToRemove = index;
        }

        $scope.tags.splice(indexToRemove, 1);
    };
});