using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddonTool
{
    public static class PageClass
    {
        //界面
        public static AddonsView addonsView = new AddonsView();
        //public static WTFMoveViewPage aligment = new WTFMoveViewPage();

        //public static SystemPage systemPage = new SystemPage();
        public static SettingView settingView = new SettingView();



        //加载次数
        public static UInt16 LoadAddonsViewCount;
        public static UInt16 LoadAligmentPageCount;
        //public static UInt16 systemPageCount;
        public static UInt16 LoadSettingViewCount;

    }
}
