$(()=>{
    window.setInterval(async ()=>{
        let r = await $.get("/Time")
        $("#time").html(r.time)
    }, 1000)
    $("#nachricht").click(async ()=>{
        console.log("click")
        let s = await $.get("/Message")
        $("#message").html(s.message)
    })
})