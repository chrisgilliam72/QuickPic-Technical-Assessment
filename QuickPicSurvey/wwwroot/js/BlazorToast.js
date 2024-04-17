window.showToast = () => {
    console.log("toast executed");
    $(".toast").toast({ delay: 3000 });
    $('.toast').toast('show');

}