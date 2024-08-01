using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SampleGame.InGame
{
    public partial class StageManager : SampleGame.Manager
    {

        StageTable stageTable;
        MonsterTable monsterTable;

        float delayTimer;

        float posX;

        private void Awake()
        {
            stageTable = new StageTable();
            monsterTable = new MonsterTable();
        }

        private void Start()
        {

        }

        public override void OnUpdate()
        {
            if (delayTimer > 1f)
            {
                //  ���� ����
                MonsterSpawn();

                //  
                delayTimer = 0f;
            }
            else
            {
                delayTimer += Time.deltaTime;
            }
        }


        public override void Preparing()
        {
            stageTable.Load("Tables/StageTable");
            monsterTable.Load("Tables/MonsterTable");
        }
        public override void Startup()
        {
            //  �� �ε�            
            var rowData = stageTable.GetRowDataByIndex<StageRowData>(0);
            var sceneName = rowData.SceneName;

            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName, UnityEngine.SceneManagement.LoadSceneMode.Additive);

            //  �÷��̾� ĳ���� �ε�
            var point = GameObject.FindObjectOfType<PlayerStartPoint>();

            var go = Instantiate(Resources.Load("Characters/P_Player_Character")) as GameObject;
            go.transform.position = point.transform.position;
            go.transform.rotation = point.transform.rotation;
        }

        private void MonsterSpawn()
        {
            var rowData = monsterTable.GetRowDataByIndex<MonsterRowData>(0);
            string path = rowData.ResourcePath;

            var go = Instantiate(Resources.Load(path)) as GameObject;
            go.transform.position = new Vector3(posX += 2f, 0f, 0f);// Vector3.zero;
            //go.transform.localScale = Vector3.one;
            go.transform.localRotation = Quaternion.identity;

            var monster = go.GetComponent<Monster>();
            monster.SetRowData(rowData);
//
        }
    }
}
