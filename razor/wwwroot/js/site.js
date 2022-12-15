$(()=>{
    window.setInterval(async () => {
        var r = await $.get("/Time")
        $("#uhr").html(r.time)
    }, 1000);
})