using Assignment3;
using Microsoft.VisualBasic;

namespace Assignment3.Tests
{
    public class SerializationTests
    {
        private ILinkedListADT users;
        private readonly string testFileName = "test_users.bin";

        [SetUp]
        public void Setup()
        {
            // Uncomment the following line
            this.users = new SLL();
            list = new SLL();


            users.AddLast(new User(1, "Joe Blow", "jblow@gmail.com", "password"));
            users.AddLast(new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef"));
            users.AddLast(new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555"));
            users.AddLast(new User(4, "Ronald McDonald", "burgers4life63@outlook.com", "mcdonalds999"));
        }

        [TearDown]
        public void TearDown()
        {
            this.users.Clear();
        }

        /// <summary>
        /// Tests the object was serialized.
        /// </summary>
        [Test]
        public void TestSerialization()
        {
            SerializationHelper.SerializeUsers(users, testFileName);
            Assert.IsTrue(File.Exists(testFileName));
        }

        /// <summary>
        /// Tests the object was deserialized.
        /// </summary>
        [Test]
        public void TestDeSerialization()
        {
            SerializationHelper.SerializeUsers(users, testFileName);
            ILinkedListADT deserializedUsers = SerializationHelper.DeserializeUsers(testFileName);
            
            Assert.IsTrue(users.Count() == deserializedUsers.Count());
            
            for (int i = 0; i < users.Count(); i++)
            {
                User expected = users.GetValue(i);
                User actual = deserializedUsers.GetValue(i);

                Assert.AreEqual(expected.Id, actual.Id);
                Assert.AreEqual(expected.Name, actual.Name);
                Assert.AreEqual(expected.Email, actual.Email);
                Assert.AreEqual(expected.Password, actual.Password);
            }
        }



        //Added Tests

        private ILinkedListADT list;

        [Test]
        public void TestIsEmptyInitially()
        {
            Assert.IsTrue(list.IsEmpty());
            Assert.AreEqual(0, list.Count());
        }

        [Test]
        public void TestAddFirst()
        {
            var user = new User(1, "Alice", "alice@mail.com", "pass");
            list.AddFirst(user);
            Assert.AreEqual(1, list.Count());
            Assert.AreEqual(user, list.GetValue(0));
        }

        [Test]
        public void TestAddLast()
        {
            var user = new User(2, "Bob", "bob@mail.com", "pass");
            list.AddLast(user);
            Assert.AreEqual(1, list.Count());
            Assert.AreEqual(user, list.GetValue(0));
        }

        [Test]
        public void TestAddAtIndex()
        {
            var user1 = new User(3, "Carol", "carol@mail.com", "pass");
            var user2 = new User(4, "Dave", "dave@mail.com", "pass");
            list.AddLast(user1);
            list.Add(user2, 0);
            Assert.AreEqual(user2, list.GetValue(0));
            Assert.AreEqual(user1, list.GetValue(1));
        }

        [Test]
        public void TestReplaceAtIndex()
        {
            var user1 = new User(5, "Eve", "eve@mail.com", "pass");
            var user2 = new User(6, "Frank", "frank@mail.com", "pass");
            list.AddLast(user1);
            list.Replace(user2, 0);
            Assert.AreEqual(user2, list.GetValue(0));
        }

        [Test]
        public void TestRemoveFirst()
        {
            var user = new User(7, "Grace", "grace@mail.com", "pass");
            list.AddFirst(user);
            list.RemoveFirst();
            Assert.AreEqual(0, list.Count());
        }

        [Test]
        public void TestRemoveLast()
        {
            var user = new User(8, "Heidi", "heidi@mail.com", "pass");
            list.AddLast(user);
            list.RemoveLast();
            Assert.AreEqual(0, list.Count());
        }

        [Test]
        public void TestRemoveAtMiddle()
        {
            var user1 = new User(9, "Ivan", "ivan@mail.com", "pass");
            var user2 = new User(10, "Judy", "judy@mail.com", "pass");
            var user3 = new User(11, "Karl", "karl@mail.com", "pass");
            list.AddLast(user1);
            list.AddLast(user2);
            list.AddLast(user3);
            list.Remove(1);
            Assert.AreEqual(2, list.Count());
            Assert.AreEqual(user3, list.GetValue(1));
        }

        [Test]
        public void TestContainsAndIndexOf()
        {
            var user = new User(12, "Liam", "liam@mail.com", "pass");
            list.AddLast(user);
            Assert.IsTrue(list.Contains(user));
            Assert.AreEqual(0, list.IndexOf(user));
        }

        [Test]
        public void TestClear()
        {
            list.AddLast(new User(13, "Mia", "mia@mail.com", "pass"));
            list.AddLast(new User(14, "Nina", "nina@mail.com", "pass"));
            list.Clear();
            Assert.AreEqual(0, list.Count());
            Assert.IsTrue(list.IsEmpty());
        }

        [Test]
        public void TestReverse()
        {
            var user1 = new User(15, "Oscar", "oscar@mail.com", "pass");
            var user2 = new User(16, "Paul", "paul@mail.com", "pass");
            var user3 = new User(17, "Quinn", "quinn@mail.com", "pass");
            list.AddLast(user1);
            list.AddLast(user2);
            list.AddLast(user3);
            list.Reverse();
            Assert.AreEqual(user3, list.GetValue(0));
            Assert.AreEqual(user2, list.GetValue(1));
            Assert.AreEqual(user1, list.GetValue(2));
        }
    }
}