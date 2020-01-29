document.addEventListener("DOMContentLoaded", function (event) {
     var currentUrl = document.URL;
     var baseUrl = '/api/';

     var codeTable = new TurboTablesLib({
          tableId: 'CodeTable',
          totalItemsAttribute: 'ctTotalItems',
          page: 1,
          pageSize: 20,
          pagerSizeOptions: [[10, 25, 50, -1], [10, 25, 50, 'All']],
          sortColumn: 'Name',
          sortDirection: 'asc',
          columnHeaderClass: 'colHeaders',
          spinnerSource: '/images/spinner-128.gif'
     });

     codeTable.setDataBinding(CodeList);

     $('#refresh').click(function () {
          CodeList(codeTable.getPage(), codeTable.getPageSize(), codeTable.getSortColumn(), codeTable.getSortDirection());
     });

     function CodeList(page, pageSize, sortColumn, direction) {
          var requestString = '?page=' + page + '&pageSize=' + pageSize + '&sortColumn=' + sortColumn + '&direction=' + direction;
          var url = baseUrl + 'code/FindAllPage' + requestString;
          var gridBodyId = 'CodeList';
          var template = 'codeListHGrid';
          //
          //  Additional logic goes here
          //
          ajaxGet({
               url: url,
               success: function (result) {
                    jsonresult = result;
                    if (parseInt(result.rowCount, 10) > 0)
                         bindGrid(gridBodyId, template, result.entities);
                    else
                         bindNoRecords(gridBodyId);
                    codeTable.endDataBinding(result.rowCount);
               },
               error: function (result, status, xhr) {
                    bindNoRecords(gridBodyId);
               }
          });
     }

     function bindGrid(grid, src, data) {
          var result = '{"' + grid + '":' + JSON.stringify(data) + "}";
          var source = $('#' + src).html();
          var template = Handlebars.compile(source);
          var html = template(JSON.parse(result));
          $("#" + grid).html(html);
     }

     function bindNoRecords(gridBodyId) {
          var html = '<tr id="noRecordsFound"><td class="lead text-left text-danger" colspan= "4">No Records Found!</td></tr>';
          $("#" + gridBodyId).html(html);
     }
});