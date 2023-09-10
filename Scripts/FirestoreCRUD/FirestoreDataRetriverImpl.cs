using Firebase.Firestore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KGSDK.FirestoreCrud
{
    public class FirestoreDataRetriverImpl : IFirestoreDataRetriever
    {
        public async Task<QuerySnapshot> FetchDataItem(string collectionName, 
            string identifier, string searchParam)
        {
            FirebaseFirestore db = FirebaseFirestore.DefaultInstance;
            CollectionReference collectionReference = db.Collection(collectionName);
            Query query = collectionReference.WhereEqualTo(identifier, searchParam);
            QuerySnapshot querySnapshot = await query.GetSnapshotAsync();
            return querySnapshot;
        }

        public async Task<QuerySnapshot> FetchDataList(string collectionName, string identifier, List<string> searchParam)
        {
            FirebaseFirestore db = FirebaseFirestore.DefaultInstance;
            CollectionReference collectionReference = db.Collection(collectionName);
            Query query = collectionReference.WhereIn(identifier, searchParam);
            QuerySnapshot querySnapshot = await query.GetSnapshotAsync();
            return querySnapshot;
        }
    }

}
