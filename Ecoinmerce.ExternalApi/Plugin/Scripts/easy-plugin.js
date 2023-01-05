
document.addEventListener('DOMContentLoaded', () => {
    var button = document.querySelector('[data-ecoinmerce]');
    var { purchaseTotal,
        purchaseIdentifier,
        ecommerceId } = button.dataset;

    button.addEventListener('click', () => {
        let height = window.innerHeight * 90 / 100;
        let width;

        if (window.innerWidth >= 1400) {
            width = window.innerWidth * 50 / 100;
        } else if (window.innerWidth >= 1000) {
            width = window.innerWidth * 70 / 100;
        } else if (window.innerWidth >= 500) {
            width = window.innerWidth * 90 / 100;
        } else if (window.innerWidth < 500) {
            width = window.innerWidth;
            height = window.innerHeight;
        }

        let top = (window.innerHeight - height) / 2;
        let left = (window.innerWidth - width) / 2;

        window.open('https://localhost:7153/api/v1/popup/ether/easy-popup?purchaseTotal='
            + purchaseTotal + '&purchaseIdentifier=' + purchaseIdentifier + '&ecommerceId=' + ecommerceId,
            null,
            `width=${width}, height=${height}, top= ${top}, left=${left}, scrollbars=no`
        );

        //var request = new request('https://localhost:7153/api/v1/popup/ether/easy-popup?purchasetotal='
        //    + purchasetotal + '&purchaseidentifier=' + purchaseidentifier + '&ecommerceid=' + ecommerceid,
        //    {
        //        method: 'get',
        //        headers: { 'access-control-allow-origin': '*' }
        //    });
        //fetch(request).then(res => {
        //    console.log(res);
        //}).catch(err => {
        //    console.log(err);
        //});
    })
});