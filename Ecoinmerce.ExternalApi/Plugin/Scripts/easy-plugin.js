
document.addEventListener('DOMContentLoaded', () => {
    var button = document.querySelector('[data-ecoinmerce]');
    var { purchaseTotal,
        purchaseIdentifier,
        ecommerceId } = button.dataset;

    button.addEventListener('click', () => {
        window.open('https://localhost:7153/api/v1/popup/ether/easy-popup?purchaseTotal='
            + purchaseTotal + '&purchaseIdentifier=' + purchaseIdentifier + '&ecommerceId=' + ecommerceId,
            null,
            {
                
                }
        );
        //var request = new Request('https://localhost:7153/api/v1/popup/ether/easy-popup?purchaseTotal='
        //    + purchaseTotal + '&purchaseIdentifier=' + purchaseIdentifier + '&ecommerceId=' + ecommerceId,
        //    {
        //        method: 'GET',
        //        headers: { 'Access-Control-Allow-Origin': '*' }
        //    });
        //fetch(request).then(res => {
        //    console.log(res);
        //}).catch(err => {
        //    console.log(err);
        //});
    })
}); 