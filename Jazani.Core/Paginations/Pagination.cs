namespace Jazani.Core.Paginations
{
    public class Pagination
    {
        public int From { get; set; }
        public int To { get; set; }
        public int PerPage { get; set; }
        public int CurrentPage { get; set; }
        public int LastPage { get; set; }
        public int Total { get; set; }


        public Pagination()
        {
        }

        public Pagination(int total, int page, int perPage)
        {
            int lastPage = (int)Math.Ceiling((decimal)total / perPage);

            if (lastPage < 1) lastPage = 1;

            int currentPage = page;


            if (page > lastPage) page = lastPage;


            int to = (page * perPage);
            if (to > total) to = total;

            int from = (page - 1) * perPage + 1;
            if (total <= 0) from = 0;



            From = from;
            To = to;
            PerPage = perPage;
            CurrentPage = currentPage;
            LastPage = lastPage;
            Total = total;
        }

        public Pagination(Pagination pagination)
        {
            From = pagination.From;
            To = pagination.To;
            PerPage = pagination.PerPage;
            CurrentPage = pagination.CurrentPage;
            LastPage = pagination.LastPage;
            Total = pagination.Total;
        }
    }
}

