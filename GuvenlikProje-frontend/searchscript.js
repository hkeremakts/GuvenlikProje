araBtn=document.getElementById("araButton");
araBtn.addEventListener("click",async()=>{
    firmaAdi=document.getElementById("firmaadi").value
    table=document.getElementById("table");
    //let table = document.querySelector("table");

    const firmaResponse = await fetch('https://localhost:7269/api/firma/getbyfirmaadicontains?firmaAdi='+firmaAdi);
    const firmaJson = await firmaResponse.json();
    firmaData=firmaJson.data;
    generateTableHead(table,firmaData);
    generateTable(table,firmaData);
    console.log(firmaData);

    function generateTable(table, data) {
      let tbody=document.getElementById("tbody");
      i=1;
        for (let element of data) {
          let row = tbody.insertRow();
          row.id="bodyrow-"+i;
          i++;
          row.addEventListener("click", () => {
            window.location.href = "main.html?firmaId="+element.firmaId+"";
          }); 
          row.addEventListener("mouseenter", () => {
            row.style.cursor = "pointer";
          });             
          for (key in element) {
            let cell = row.insertCell();
            text=document.createTextNode(element[key]);
            cell.appendChild(text);
          }
        }
      }
    function generateTableHead(table, data) {
        let thead = document.getElementById("thead");
        let row = thead.insertRow();
        var keyNames=Object.keys(data[0])
        for(let i=0;i<keyNames.length;i++){
          let th=document.createElement("th");
          let text=document.createTextNode(keyNames[i]);
          th.appendChild(text);
          row.appendChild(th)
        }
      }  

})
