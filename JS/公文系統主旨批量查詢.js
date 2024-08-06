function timeout(ms) {
    return new Promise(resolve => setTimeout(resolve, ms));
}

let searchDataList = [];
console.log("查詢資料數：" + searchDataList.length);

async function search(text) {
    let searchField = window.top.frames["FUNC"].document.getElementById("ctl00_MainPlace_ctxtAdvancedtCodeDesc_TextBox");
    searchField.value = text;

    let searchButton = window.top.frames["FUNC"].document.getElementById("ctl00_MainPlace_bbtnAdvancedQuery");
    searchButton.click();
    await timeout(15000);
}

async function searchAll() {
    let searchDataListLength = searchDataList.length;
    for (let count = 0; count < searchDataListLength; ++count) {
        let searchData = searchDataList[count];
        await search(searchData).then(() => {
            let table = window.top.frames["FUNC"].document.getElementById("G_ctl00xMainPlacexugPARAMETER");
            let rowLength = table.rows.length;
            if (rowLength < 2) {
                return;
            }

            let result = "搜尋結果－主旨：" + searchData + "\r\n";
            for (let i = 1; i < rowLength; ++i) {
                let row = table.rows[i];
                let cellLength = row.cells.length;

                for (let y = 0; y < cellLength; ++y) {
                    result += row.cells[y].innerText;
                    if (y < cellLength - 1) {
                        result += "\t";
                    }
                }

                if (i < rowLength - 1) {
                    result += "\r\n";
                }
            }
            console.log(result);
        });
        console.log("查詢進度：" + (count + 1) + "／" + searchDataList.length);
    }
}

searchAll();