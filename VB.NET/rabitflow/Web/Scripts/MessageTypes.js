function AlertMessageType(message) {
    this.Message = message;
    this.Show = function () {
        alert(this.Message);
    }
}

function ConfirmMessageType(message) {
    this.Message = message;
    this.Show = function () {
        return confirm(this.Message);
    }
}
