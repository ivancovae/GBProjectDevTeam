using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Games
{
    public class Shop : BaseObjectScene
    {
        [SerializeField] private List<CellStore> _cells = new List<CellStore>();
        [SerializeField] private List<BookCase> _bookCases = new List<BookCase>();

        protected override void Awake()
        {
            base.Awake();

            var cells = GameObject.FindObjectsOfType<CellStore>();
            foreach (var cell in cells)
            {
                _cells.Add(cell);
            }
        }
    }
}