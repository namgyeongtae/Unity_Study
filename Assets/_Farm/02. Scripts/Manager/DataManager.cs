using UnityEngine;

namespace Farm
{
    public class DataManager : SingletonCore<DataManager>
    {
        private int selectCharacterIndex;
        public int SelectCharacterIndex 
        {
            get
            {
                return selectCharacterIndex;
            }
            set
            {
                Debug.Log("SelectCharacterIndex: " + value);
                selectCharacterIndex = value;
            }
        }
    }
}

