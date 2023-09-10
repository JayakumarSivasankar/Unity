using Firebase.Firestore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KGSDK.FirestoreCrud
{
    public interface IFirestoreDataRetriever
    {
        public Task<QuerySnapshot> FetchDataItem(string collectionName, string identifier, string searchParam);
        public Task<QuerySnapshot> FetchDataList(string collectionName, string identifier, List<string> searchParam);
    }

}
