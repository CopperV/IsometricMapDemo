using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

namespace _Demo
{
    [RequireComponent(typeof(MeshRenderer))]
    public class InteractiveObject : MonoBehaviour, ISelectable
    {

        public Material Material;
        private MeshRenderer Renderer;

        private void Awake()
        {
            Renderer = GetComponent<MeshRenderer>();
        }

        public void Select(GameObject Target)
        {
            List<Material> materials = new List<Material>();
            Renderer.GetMaterials(materials);

            if (!materials.Contains(Material))
            {
                materials.Add(Material);
                Renderer.SetMaterials(materials);
            }
        }

        public void Unselect(GameObject Target)
        {
            List<Material> materials = new List<Material>();
            Renderer.GetMaterials(materials);

            materials
                .Where(material => Material.shader.Equals(material.shader))
                .ToList()
                .ForEach(material => materials.Remove(material));
            Renderer.SetMaterials(materials);
        }
    }
}

