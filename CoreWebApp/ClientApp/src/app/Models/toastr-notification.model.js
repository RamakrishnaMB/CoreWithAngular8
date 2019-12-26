"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var Notification = /** @class */ (function () {
    function Notification() {
    }
    return Notification;
}());
exports.Notification = Notification;
var NotificationType;
(function (NotificationType) {
    NotificationType[NotificationType["Success"] = 0] = "Success";
    NotificationType[NotificationType["Error"] = 1] = "Error";
    NotificationType[NotificationType["Info"] = 2] = "Info";
    NotificationType[NotificationType["Warning"] = 3] = "Warning";
})(NotificationType = exports.NotificationType || (exports.NotificationType = {}));
//# sourceMappingURL=toastr-notification.model.js.map