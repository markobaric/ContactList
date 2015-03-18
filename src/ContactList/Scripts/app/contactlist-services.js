ContactListApp.constant('ConfigurationService', {
    rootUrl: '/api'
    //rootUrl: 'http://localhost/ContactList/api'
});
ContactListApp.factory('ContactService', function ($http, ConfigurationService) {
    return {
        GetAll: function (search, sort, desc) {
            return $http.post(ConfigurationService.rootUrl + '/Contact/GetAll', { search: search, sort: sort, desc: desc });
        },
        GetById: function (contactId) {
            return $http.post(ConfigurationService.rootUrl + '/Contact/GetById', contactId);
        },
        Insert: function (firstName, lastName, address, phones, emails, tags) {
            return $http.post(ConfigurationService.rootUrl + '/Contact/Insert', { firstName: firstName, lastName: lastName, address: address, phones: phones, emails: emails, tags: tags });
        },
        Update: function (id, firstName, lastName, address, phones, emails, tags) {
            return $http.post(ConfigurationService.rootUrl + '/Contact/Update', { id: id, firstName: firstName, lastName: lastName, address: address, phones: phones, emails: emails, tags: tags });
        },
        Delete: function (contactId) {
            return $http.post(ConfigurationService.rootUrl + '/Contact/Delete', contactId);
        }
    };
});
ContactListApp.factory('PhoneService', function ($http, ConfigurationService) {
    return {
        Add: function (phone) {
            return $http.post(ConfigurationService.rootUrl + '/Phone/Insert', {phone: phone});
        },
        Delete: function (phoneId) {
            return $http.post(ConfigurationService.rootUrl + '/Phone/Delete', phoneId );
        }
    };
});
ContactListApp.factory('EmailService', function ($http, ConfigurationService) {
    return {
        Add: function (email) {
            return $http.post(ConfigurationService.rootUrl + '/Email/Insert', { email: email });
        },
        Delete: function (emailId) {
            return $http.post(ConfigurationService.rootUrl + '/Email/Delete', emailId );
        }
    };
});
ContactListApp.factory('TagService', function ($http, ConfigurationService) {
    return {
        Add: function (tag) {
            return $http.post(ConfigurationService.rootUrl + '/Tag/Insert', { tag: tag });
        },
        Delete: function (tagId) {
            return $http.post(ConfigurationService.rootUrl + '/Tag/Delete', tagId );
        }
    };
});
ContactListApp.factory('EntryTypeService', function ($http, ConfigurationService) {
    return {
        GetAll: function () {
            return $http.get(ConfigurationService.rootUrl + '/EntryType/GetAll');
        }
    };
});