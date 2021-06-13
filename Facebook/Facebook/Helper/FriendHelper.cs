using Facebook.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook.Helper
{
    public static class FriendHelper
    {
        /// <summary>
        /// Kiểm  tra A và B có là bạn
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool AIsFriendB(User a, User b)
        {
            return StringHelper.StringToStringList(a.Friend).Contains(b.ID.ToString());
        }

        #region Friend

        /// <summary>
        /// Xóa id của b trong danh sách friend a
        /// </summary>
        /// <param name="a"></param>
        /// <param name="bID"></param>
        public static void A_DeleteFriend_B(User a, int bID)
        {
            var list = StringHelper.StringToIntList(a.Friend);

            if (list.Contains(bID))
            {
                list.Remove(bID);
            }

            a.Friend = StringHelper.IntListToString(list);
        }

        /// <summary>
        /// Thêm id của b trong danh sách friend a
        /// </summary>
        /// <param name="a"></param>
        /// <param name="bID"></param>
        public static void A_AddFriend_B(User a, int bID)
        {
            var list = StringHelper.StringToIntList(a.Friend);

            if (!list.Contains(bID))
            {
                list.Add(bID);
            }

            a.Friend = StringHelper.IntListToString(list);
        }

        /// <summary>
        /// Nếu có thì xóa, nếu không thì thêm
        /// </summary>
        /// <param name="a"></param>
        /// <param name="bID"></param>
        public static void A_AddOrDelete_Friend_B(User a, int bID)
        {
            var list = StringHelper.StringToIntList(a.Friend);

            if (list.Contains(bID))
            {
                list.Remove(bID);
            }
            else
            {
                list.Add(bID);
            }

            a.Friend = StringHelper.IntListToString(list);
        }

        #endregion


        #region Requested Friend

        /// <summary>
        /// Kiểm tra A đã gửi request B chưa
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool A_SendRequest_B(User a, User b)
        {
            return StringHelper.StringToStringList(b.RequestedFriend).Contains(a.ID.ToString());
        }

        /// <summary>
        /// Nếu có thì xóa, nếu không thì thêm
        /// </summary>
        /// <param name="a"></param>
        /// <param name="bID"></param>
        public static void A_AddOrDelete_Request_B(User a, int bID)
        {
            var list = StringHelper.StringToIntList(a.RequestedFriend);

            if (list.Contains(bID))
            {
                list.Remove(bID);
            }
            else
            {
                list.Add(bID);
            }

            a.RequestedFriend = StringHelper.IntListToString(list);
        }

        /// <summary>
        /// Xóa id của b trong danh sách requested friend a
        /// </summary>
        /// <param name="a"></param>
        /// <param name="bID"></param>
        public static void A_DeleteRequestedFriend_B(User a, int bID)
        {
            var list = StringHelper.StringToIntList(a.RequestedFriend);

            if (list.Contains(bID))
            {
                list.Remove(bID);
            }

            a.RequestedFriend = StringHelper.IntListToString(list);
        }

        /// <summary>
        /// Thêm id của b trong danh sách requested friend a
        /// </summary>
        /// <param name="a"></param>
        /// <param name="bID"></param>
        public static void A_AddRequestedFriend_B(User a, int bID)
        {
            var list = StringHelper.StringToIntList(a.RequestedFriend);

            if (!list.Contains(bID))
            {
                list.Add(bID);
            }

            a.RequestedFriend = StringHelper.IntListToString(list);
        }

        #endregion

        #region Blocked Friend

        /// <summary>
        /// Thêm id của b trong danh sách blocked a
        /// </summary>
        /// <param name="a"></param>
        /// <param name="bID"></param>
        public static void A_AddBlockedFriend_B(User a, int bID)
        {
            var list = StringHelper.StringToIntList(a.BlockedFriend);

            if (!list.Contains(bID))
            {
                list.Add(bID);
            }

            a.BlockedFriend = StringHelper.IntListToString(list);
        }

        #endregion

        #region By Blocked Friend

        /// <summary>
        /// Thêm id của b trong danh sách blocked a
        /// </summary>
        /// <param name="a"></param>
        /// <param name="bID"></param>
        public static void A_AddByBlockedFriend_B(User a, int bID)
        {
            var list = StringHelper.StringToIntList(a.ByBlockedFriend);

            if (!list.Contains(bID))
            {
                list.Add(bID);
            }

            a.ByBlockedFriend = StringHelper.IntListToString(list);
        }

        #endregion
    }
}
