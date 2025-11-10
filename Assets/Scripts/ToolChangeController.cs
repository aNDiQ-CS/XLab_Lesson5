using UnityEngine;

public class ToolChangeController : MonoBehaviour
{
    [SerializeField] private GameObject[] m_toolsPrefabs;
    [SerializeField] private GameObject[] m_tools;

    private int previousRandomTool;    

    public void ChangeTools()
    {
        int randomToolIndex = Random.Range(0, m_toolsPrefabs.Length);
        if (randomToolIndex == previousRandomTool)
        {
            randomToolIndex = ++randomToolIndex % m_toolsPrefabs.Length;
        }
        
        previousRandomTool = randomToolIndex;
        GameObject randomTool = m_toolsPrefabs[randomToolIndex];

        for (int i = 0; i < m_tools.Length; i++)
        {            
            GameObject t = m_tools[i];
            GameObject newTool = Instantiate(randomTool, t.transform.position, t.transform.rotation, t.transform.parent);
            Destroy(t);
            m_tools[i] = newTool;

            // ≈сть вопрос: € считаю этот метод неоптимизированным, а как было бы правильно?
        }
    }

}
