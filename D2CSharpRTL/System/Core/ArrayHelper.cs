/*
  D2CSharp Runtime Library (RTL)

  This file is implemented directly in C# and provides supporting
  functionality for the runtime library. It is not generated from
  a Delphi source file.

  Copyright (c) 2026 Dr. Detlef Meyer-Eltz, t2t-soft
  SPDX-License-Identifier: MPL-2.0

  This Source Code Form is subject to the terms of the Mozilla Public
  License, v. 2.0. If a copy of the MPL was not distributed with this
  file, You can obtain one at https://mozilla.org/MPL/2.0/.

  Part of the D2CSharp project by t2t-soft.
*/

using static System.SystemInterface;

namespace System
{
    using System;

    public static class ArrayHelper
    {
        //public static T CreateJaggedArray<T>(int[] dimensions, Func<int[], T> initializer, int depth = 0, int[] indices = null)
        //{
        //    if (indices == null)
        //    {
        //        indices = new int[dimensions.Length];
        //    }

        //    // Prüfen, ob wir die tiefste Ebene erreicht haben
        //    if (depth == dimensions.Length - 1)
        //    {
        //        // Erstellen und initialisieren des letzten Arrays
        //        var lastArray = new T[dimensions[depth]];
        //        for (int i = 0; i < dimensions[depth]; i++)
        //        {
        //            indices[depth] = i;
        //            lastArray[i] = initializer(indices);
        //        }
        //        return (T)(object)lastArray;
        //    }
        //    else
        //    {
        //        // Rekursives Erstellen des Arrays für tiefere Dimensionen
        //        var outerArray = new object[dimensions[depth]];
        //        for (int i = 0; i < dimensions[depth]; i++)
        //        {
        //            indices[depth] = i;
        //            outerArray[i] = CreateJaggedArray<T>(dimensions, initializer, depth + 1, indices);
        //        }
        //        return (T)(object)outerArray;
        //    }
        //}


        public static T[][] CreateJaggedArray<T>(int rows, int columns)
        {
            T[][] result = new T[rows][];
            for (int i = 0; i < rows; i++)
            {
                result[i] = new T[columns];
            }
            return result;
        }

        public static T[][][] CreateJaggedArray<T>(int d1, int d2, int d3)
        {
            T[][][] result = new T[d1][][];
            for (int i = 0; i < d2; i++)
            {
                result[i] = CreateJaggedArray<T>(d2, d3);
            }
            return result;
        }

        //public static T CreateJaggedArray<T>(int[] dimensions, int depth = 0)
        //{
        //    if (depth == dimensions.Length - 1)
        //    {
        //        // Letzte Dimension: Einfaches eindimensionales Array
        //        return (T)(object)new object[dimensions[depth]];
        //    }

        //    // Rekursiv weitere Dimensionen erstellen
        //    var outerArray = new object[dimensions[depth]];
        //    for (int i = 0; i < dimensions[depth]; i++)
        //    {
        //        outerArray[i] = CreateJaggedArray<T>(dimensions, depth + 1);
        //    }

        //    return (T)(object)outerArray;
        //}
        //public static object CreateJaggedArray<T>(int[] dimensions)
        //{
        //    if (dimensions == null || dimensions.Length == 0)
        //    {
        //        throw new ArgumentException("Dimensions array must not be null or empty.");
        //    }

        //    return CreateJaggedArrayRecursively<T>(dimensions, 0);
        //}

        //public static object CreateJaggedArrayRecursively<T>(int[] dimensions, int depth)
        //{
        //    // Erstelle das Array für die aktuelle Dimension
        //    Array array = Array.CreateInstance(typeof(object), dimensions[depth]);

        //    // Wenn dies nicht die letzte Dimension ist, rekursiv innere Arrays erstellen
        //    if (depth < dimensions.Length - 1)
        //    {
        //        for (int i = 0; i < dimensions[depth]; i++)
        //        {
        //            array.SetValue(CreateJaggedArrayRecursively<T>(dimensions, depth + 1), i);
        //        }
        //    }
        //    else
        //    {
        //        // Letzte Dimension: Erstelle ein Array des Typs T
        //        for (int i = 0; i < dimensions[depth]; i++)
        //        {
        //            array.SetValue(default(T), i);
        //        }
        //    }

        //    return array;
        //}
        //public static object CreateJaggedArray<T>(int[] dimensions)
        //{
        //    if (dimensions == null || dimensions.Length == 0)
        //    {
        //        throw new ArgumentException("Dimensions array must not be null or empty.");
        //    }

        //    return CreateJaggedArrayRecursively<T>(dimensions, 0);
        //}

        //private static object CreateJaggedArrayRecursively<T>(int[] dimensions, int depth)
        //{
        //    // Erstelle das Array für die aktuelle Dimension
        //    Array array = Array.CreateInstance(depth == dimensions.Length - 1 ? typeof(T) : typeof(object), dimensions[depth]);

        //    // Wenn dies nicht die letzte Dimension ist, rekursiv innere Arrays erstellen
        //    if (depth < dimensions.Length - 1)
        //    {
        //        for (int i = 0; i < dimensions[depth]; i++)
        //        {
        //            array.SetValue(CreateJaggedArrayRecursively<T>(dimensions, depth + 1), i);
        //        }
        //    }

        //    return array;
        //}
    }
}