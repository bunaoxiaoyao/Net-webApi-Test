namespace WebApi.Service.TableService.Dto
{
    public class ResultDto 
    {
        public int code { get; set; }

        public List<TableDataDto>  tableDataDtos { get; set; }
    }


    public class TableDataDto
    {
        public string Name { get; set; }

        public string Date { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Tag { get; set; }
    }
}
