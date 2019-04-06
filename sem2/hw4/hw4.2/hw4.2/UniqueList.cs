using System;

namespace hw4._2
{
    /// <summary>
    /// Singly linked list with no duplicate values.
    /// </summary>
    public class UniqueList : List
    {
        /// <summary>
        /// Adds new element in list by its position if the element does not exists.
        /// </summary>
        /// <param name="position">Position of the element to add.</param>
        /// <param name="data">Element to add.</param>
        public override void AddElement(int position, string data)
        {
            if (base.Exists(data))
            {
                throw new ElementAlreadyExistsException();
            }

            base.AddElement(position, data);
        }

        public override void SetData(int position, string data)
        {
            if (base.Exists(data))
            {
                throw new ElementAlreadyExistsException();
            }

            base.SetData(position, data);
        }
    }
}
