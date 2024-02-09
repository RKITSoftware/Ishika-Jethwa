async function getData(url){
    const response = await fetch(url);
    console.log(response);
    var data = await response.json();
    console.log(data);
}

getData("http://127.0.0.1:5500/demo/info.json")