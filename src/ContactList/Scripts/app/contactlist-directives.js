// Directive that shows error notification when "$rootScope.error" has value set
ContactListApp.directive('notifyError', function ($timeout) {
    return {
        restrict: 'A',
        link: function (scope, elem, attrs) {
            scope.$watch("error", function (newValue, oldValue) {
                if (newValue != undefined) {
                    var n = noty({ text: newValue, layout: 'bottom', });
                    //Close
                    setTimeout(function () {
                        n.close();
                    }, 5000);
                }
            });
        }
    };
});