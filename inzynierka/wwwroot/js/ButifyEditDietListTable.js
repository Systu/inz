$('#IndexTable').DataTable({
    "lengthMenu": [4, 5, 25, 50, 75, 100],
    "pagingType": "full_numbers",
    language: {
        processing: "Przetwarzanie",
        search: "Szukaj:",
        lengthMenu: "Pokaż _MENU_ wyników",
        info: "Pokazuje od _START_ do _END_ z _TOTAL_ wyników",
        infoEmpty: "Brak wyników do wyświetlenia",
        infoFiltered: "(Przefiltrowano z _MAX_ rekordu)",
        infoPostFix: "",
        loadingRecords: "Ładowanie Rekordów",
        zeroRecords: "Tabela jest pusta",
        emptyTable: "Tabela jest pusta",
        paginate: {
            first: "Pierwsza",
            previous: "Poprzednia",
            next: "Następna",
            last: "Ostatnia"
        },
        aria: {
            sortAscending: ": Aktywne sortowanie rosnąco",
            sortDescending: ": Aktywne sortowanie malejąco"
        }
    }
});