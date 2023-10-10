using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Service.TableService.Dto;

namespace ASP.NET_Core.Controllers
{
    [Route("Api/[controller]")]
    [Produces("application/json")]
    [EnableCors("CorsPolicy")]
    public class WeChatController : Controller
    {
        [HttpPost("MyExample")]
        public ActionResult<IEnumerable<ResultDto>>  MyExample([FromBody] TableDataDto tableDataDto)
        {
            ResultDto resultDto = new ResultDto() 
            {
                tableDataDtos = new List<TableDataDto>()
            };
            var date = DateTime.Now.ToString("yyyy-MM-dd");
            List<TableDataDto> tableData = new List<TableDataDto>() 
            {
                new TableDataDto(){ 
                    Date= date,
                    Tag = "臭狗",
                     Description= "一只老六",
                     Name ="小dog",
                      Title = "臭狗没洗澡"
                },
                new TableDataDto(){
                    Date= date,
                    Tag = "哈鸡米",
                     Description= "一只老七",
                     Name ="小白",
                      Title = "臭狗没洗澡"
                }
            };
            tableDataDto.Date= date;
            tableData.Add(tableDataDto);
            resultDto.code = 200;
            resultDto.tableDataDtos.AddRange(tableData);
            //这边可以进行任意操作，比如数据存入或者取出数据库等
            return Ok(resultDto);
        }
    }
}
