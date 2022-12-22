$(async ()=>{
    let r = await $.get("/Time")
    $("#time").html(r.time)
    let s = await $.get("/Message")
    $("#message").html(s.message)
})