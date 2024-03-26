using ArrayManagementClassLibrary;
using FluentAssertions;


namespace ArrayManagement.Tests.ClassLibrary
{
    public class ArraySorterTestClassLibrary
    {
        [Fact]
        public void TestFindIndexOfMin()
        {
            int[] array = { 1, 2, 3 };
            uint indexOfMin = ArraySorterClassLibrary.FindIndexOfMin(array, 0, 2);
            Assert.Equal((uint) 0, indexOfMin);
            //Assert.Equal(0u, indexOfMin)
        }

        [Fact]
        public void TestFindIndexOfMin_1()
        {
            try
            {
                int[] array = { 1, 2, 3 };
                uint indexOfMin = ArraySorterClassLibrary.FindIndexOfMin(array, 10, 20);
                Assert.True(false);
            }
            catch(IndexOutOfRangeException)
            {
                Assert.True(true);
            }
            
        }

        [Fact]
        public void TestFindIndexOfMin_2()
        {
            
            int[] array = { -1, 2, 3, -8, 5 };
            uint indexOfMin = ArraySorterClassLibrary.FindIndexOfMin(array, 2, 3);
            Assert.Equal(3u, indexOfMin);
          
        }

        [Theory]
        [InlineData(2, 3, 3)]
        [InlineData(0, 4, 3)]
        [InlineData(0, 2, 0)]

        public void TestFindIndexOfMin_3(uint indexFrom, uint indexTo, uint indexOfMin)
        {
            int[] array = [-1, 2, 3, -8, 5];
            uint actualIndexOfMin = ArraySorterClassLibrary.FindIndexOfMin(array, indexFrom, indexTo);
            Assert.Equal(indexOfMin, actualIndexOfMin);
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 5, -1, 7 }, 0, 3, 3)]
        [InlineData(new int[] { 1, 2, 5, -1, 7 }, 2, 4, 3)]
        [InlineData(new int[] { 1, 2, 5, -1, 7 }, 0, 1, 0)]
        [InlineData(new int[] { -1, -2, -5, -1, 7 }, 1, 4, 2)]

        public void TestFindIndexOfMin_4(int [] array, uint indexFrom, uint indexTo, uint indexOfMin)
        {
            
            uint actualIndexOfMin = ArraySorterClassLibrary.FindIndexOfMin(array, indexFrom, indexTo);
            Assert.Equal(indexOfMin, actualIndexOfMin);
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 5, -1, 7 }, 0, 3, 3)]
        [InlineData(new int[] { 1, 2, 5, -1, 7 }, 2, 4, 3)]
        [InlineData(new int[] { 1, 2, 5, -1, 7 }, 0, 1, 0)]
        [InlineData(new int[] { -1, -2, -5, -1, 7 }, 1, 4, 2)]
        [InlineData(new int[] { -1, -2, 3, -8, 5 }, 2, 3, 3)]
        [InlineData(new int[] { -1, -2, 3, -8, 5 }, 0, 4, 3)]
        [InlineData(new int[] { -1, 2, 3, -8, 5 }, 0, 2, 0)]

        public void TestFindIndexOfMin_should_work(int[] array, uint indexFrom, uint indexTo, uint indexOfMin)
        {

            uint actualIndexOfMin = ArraySorterClassLibrary.FindIndexOfMin(array, indexFrom, indexTo);
            actualIndexOfMin.Should().Be(indexOfMin);
        }

        [Fact]
        public void TestFindIndexOfMin_whit_indexes_than_array_length_should_throw_IndexOutOfRangerExcep()
        {
            Action action =
                () =>
                {
                    int[] array = [3, 2, 1];
                    uint indexOfMin = ArraySorterClassLibrary.FindIndexOfMin(array, 10, 20);
                };
            action.Should().Throw<IndexOutOfRangeException>();

        }


     

        [Theory]
        [InlineData(new int[] { 1, 2, 5, -1 }, 0, 3, new int[] { -1, 2, 5, 1 })]
        [InlineData(new int[] { 1, 2, 5, -1 }, 1, 2, new int[] { -1, 2, 5, 1 })]
        [InlineData(new int[] { 1, 2, 5, -1 }, 3, 3, new int[] { -1, 2, 5, 1 })]
        public void TestSwapElements_should_work(int[] array, uint i, uint j, int[] expectedArray)

        {
            ArraySorterClassLibrary.SwapElements(array, i, j);
            array.Should().BeEquivalentTo(expectedArray);

        }



        [Theory]
        [InlineData(new int[] { 1, 2, 5, -1 }, 0, 3)] //new int[] { -1, 2, 5, 1 })]
        [InlineData(new int[] { 1, 2, 5, -1 }, 1, 2)]//new int[] { -1, 2, 5, 1 })]
        [InlineData(new int[] { 1, 2, 5, -1 }, 3, 3)]//new int[] { -1, 2, 5, 1 })]
        public void TestSwapElements_should_work_2(int[] array, uint i, uint j)

        {
            int valueAtI = array[i];
            int valueAtJ = array[j];

            ArraySorterClassLibrary.SwapElements(array, i, j);

            valueAtI.Should().Be(array[j]);
            valueAtJ.Should().Be(array[i]);
        }



        [Theory]
        [InlineData(new int[] { 1, 2, 5, -1 })]
       
        public void TestSortArray(int[] array)

        {
            ArraySorterClassLibrary.SortArray(array);

        }

        [Theory]
        [InlineData(new int[] { 1, 2, 5, -1 })]
        [InlineData(new int[] { 4, 8, 1, 2, 5, -1 })]
        [InlineData(new int[] { 1, 2, 3, 4, 5, 6 })]


        public void TestSortArray_2(int[] array)

        {
            ArraySorterClassLibrary.SortArray(array);
            array.Should().BeInAscendingOrder();

        }

        [Theory]
        [InlineData(new int[] { 1, 2, 5, -1 })]

        public void TestSortArray_3(int[] array)

        {
            array.Should().NotBeInAscendingOrder();
            ArraySorterClassLibrary.SortArray(array);
            array.Should().BeInAscendingOrder();

        }


        [Theory]
        [InlineData(new int[] { 1, 2, 5, -1 })]
        [InlineData(new int[] { 4, 8, 1, 2, 5, -1 })]
        [InlineData(new int[] { 1, 2, 3, 4, 4, 5, 6 })]


        public void TestSortArray_4(int[] array)


        {
            var copyArray = array.ToArray();
            ArraySorterClassLibrary.SortArray(array);
            array.Should().Equal(copyArray.OrderBy(x => x).ToArray());

        }

        [Theory]
        [InlineData(new int[] { 1, 2, 5, -1 })]
        [InlineData(new int[] { 4, 8, 1, 2, 5, -1 })]
        [InlineData(new int[] { 1, 2, 3, 4, 4, 5, 6 })]


        public void TestSortArray_5(int[] array)

        {
            var sortedArray = array.OrderBy(x => x).ToArray();
            ArraySorterClassLibrary.SortArray(array);
            array.Should().Equal(sortedArray);

        }

    }

}