using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WA.CMS
{
    /// <summary>
    /// 取得系統參設定
    /// </summary>
    public class SystemParamter
    {
	    private readonly ISystemParameterRepo _repo;

	    public SystemParamter(ISystemParameterRepo repo)
	    {
		    _repo = repo;
	    }

        /// <summary>
        /// 根據分類,key,取得一筆設定值
        /// </summary>
        /// <param name="category"></param>
        /// <param name="key"></param>
        /// <returns></returns>
	    public string GetSetting(string category, string key)
        {
	        return _repo.Load(category, key);
        }
    }

    public interface ISystemParameterRepo
    {
        /// <summary>
        /// 根據分類,key,取得一筆設定值, 若找不到, 傳回例外
        /// </summary>
        /// <param name="category"></param>
        /// <param name="key"></param>
        /// <returns></returns>
	    string Load(string category, string key);
    }
    public class SystemParameterRepository : ISystemParameterRepo
    {
	    public string Load(string category, string key)
	    {
		    if (category == "basic" && key == "cities")
		    {
			    return "1=台北;2=台中;3=高雄";
		    }else if (category == "basic" && key == "order-status")
		    {
			    return "[{\"id\":1,\"text\":\"未結案\"},{\"id\":2,\"text\":\"已結案\"},{\"id\":3,\"text\":\"已取消\"},]";
		    }

		    throw new Exception($"找不到符合的系統參數,category={category}, key={key}");
	    }
    }
}
