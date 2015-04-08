namespace GameLogic.Map
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;

    using GameLogic.Map.Fields;
    using GameLogic.Exceptions;
    using GameLogic.Map.Fields.Institutions;
    using GameLogic.Map.Fields.Institutions;

    public class GameMap : IEnumerable<Field>
    {
        internal GameMap(string name, int mapRows, int mapCols, int startRow, int startColumn)
        {
            this.Name = name;
            this.FieldsMatrix = new Field[mapRows, mapCols];
            this.Start = new StartField(Color.WhiteSmoke, startRow, startColumn);
            this.FieldsMatrix[startRow, startColumn] = this.Start;
        }

        public Field[,] FieldsMatrix { get; private set; }

        public StartField Start { get; set; }

        public string Name { get; internal set; }

        internal static bool FieldCanBeReached(Field firstField, Field secondField, int diceValue)
        {
            foreach (var fields in firstField.NextFields)
            {
                var tempFiled = fields;
                for (int i = 0; i < diceValue - 1; i++)
                {
                    tempFiled = tempFiled.NextFields[0];
                }
                if (tempFiled == secondField)
                {
                    return true;
                }
            }

            return false;
        }

        internal void AddField(Field fieldToBeAdd, Field[] previousFields)
        {
            if (FieldsMatrix[fieldToBeAdd.Row, fieldToBeAdd.Column] != null)
            {
                throw new InvalidOperationException("You try to add field on position(row, col), where already exists one!");
            }

            if (previousFields.Length < 1)
            {
                throw new GameMapInvalidConnectivityException("Every field must have at least one previous field", fieldToBeAdd);
            }

            this.FieldsMatrix[fieldToBeAdd.Row, fieldToBeAdd.Column] = fieldToBeAdd;

            foreach (var field in previousFields)
            {
                field.NextFields.Add(fieldToBeAdd);
                fieldToBeAdd.PrevFields.Add(field);
            }
        }

        internal static GameMap GetMapByName(string mapName)
        {
            return Repository.Maps.GetByName(mapName);
        }

        public IEnumerator<Field> GetEnumerator()
        {
            HashSet<Field> mapFields = new HashSet<Field>();
            GetAllFields(this.Start, mapFields);

            return mapFields.GetEnumerator();
        }

        private void GetAllFields(Field currField, ICollection<Field> mapFields)
        {
            if (mapFields.Contains(currField))
            {
                return;
            }
            else
            {
                mapFields.Add(currField);

                foreach (var field in currField.NextFields)
                {
                    GetAllFields(field, mapFields);
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}