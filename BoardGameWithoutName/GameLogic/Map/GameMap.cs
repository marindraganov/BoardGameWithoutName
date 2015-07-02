namespace GameLogic.Map
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Drawing;

    using GameLogic.Exceptions;
    using GameLogic.Map.Fields;
    using GameLogic.Map.Fields.Institutions;

    public class GameMap : IEnumerable<Field>
    {
        private static Random rnd = new Random();

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

        public IEnumerator<Field> GetEnumerator()
        {
            HashSet<Field> mapFields = new HashSet<Field>();
            this.GetAllFields(this.Start, mapFields);

            return mapFields.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        internal static bool FieldCanBeReached(Field firstField, Field secondField, int diceValue)
        {
            return DFS(firstField, secondField, diceValue);
        }

        internal static bool PathContainsStart(Field firstField, Field secondField)
        {
            bool contain = false;

            if(secondField is StartField)
            {
                return true;
            }

            int counter = 1;

            foreach (var field in firstField.NextFields)
            {
                if (StartFinderDFS(field,  firstField, secondField, counter))
                {
                    contain = true;
                }
            }

            return contain;
        }

        private static bool StartFinderDFS(Field currField, Field firstField, Field secondField, int counter)
        {
            if (currField == firstField || currField == secondField || counter > 12)
            {
                return false;
            }
            else if (currField is StartField)
            {
                return true;
            }
            else
            {
                bool contain = false;

                foreach (var field in currField.NextFields)
                {
                    if (StartFinderDFS(field, firstField, secondField, counter + 1))
                    {
                        contain = true;
                    }
                }

                return contain;
            }
        }

        private static bool DFS(Field field, Field target, int length)
        {
            if (length == 0)
            {
                if (field == target)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            bool flag = false;

            foreach (var f in field.NextFields)
            {
                if (DFS(f, target, length - 1))
                {
                    flag = true;
                }
            }

            return flag;
        }

        internal static GameMap GetMapByName(string mapName)
        {
            return Repository.Maps.GetByName(mapName);
        }

        internal static Field GetRandomField(GameMap map)
        {
            List<Field> mapFields = new List<Field>();
            map.GetAllFields(map.Start, mapFields);

            int rndIndex = rnd.Next(0, mapFields.Count);

            return mapFields[rndIndex];
        }

        internal void AddField(Field fieldToBeAdd, Field[] previousFields)
        {
            if (this.FieldsMatrix[fieldToBeAdd.Row, fieldToBeAdd.Column] != null)
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
                    this.GetAllFields(field, mapFields);
                }
            }
        }
    }
}