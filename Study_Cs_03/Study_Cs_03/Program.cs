using System;

class Cat
{
	public string Name;
	public int Weight;
	//생성자
	public Cat(string name)
	{
		Name = name;
		Console.WriteLine("고양이의 이름은 "+Name+" 입니다.");
	}

	//오버로딩
	public Cat(string name, int weight)
    {
		Name = name;
		Weight = weight;
		Console.WriteLine("고양이의 이름은 " + Name + "이며, 몸무게는 " + Weight + "kg 입니다.");
    }

	//소멸자
    ~Cat()
    {
		Console.WriteLine(Name + "이(가) 사라집니다.");
    }
}

//상속
class Robot
{
	public void Move()
    {
		Console.WriteLine("로봇이 움직입니다.");
    }
    ~Robot()
    {
		Console.WriteLine("로봇이 사라집니다.");
    }
}
class CleanRobot : Robot
{
	public void Clean()
    {
		Console.WriteLine("청소를 시작합니다.");
    }
	//오버라이딩
	public new void Move()
    {
		Console.WriteLine("청소 로봇이 움직입니다.");
    }
    //~CleanRobot()
    //{
    //    Console.WriteLine("청소 로봇이 사라집니다.");
    //}
}
//접근 제한자
class Human{
	private string Name;

	public Human(string name)
    {
		Name = name;
		Console.WriteLine("사람의 이름은 " + Name + "입니다.");
    }

	public void SetName(string name)
    {
		this.Name = name;
    }
	public string GetName()
    {
		return Name;
    }
}

class MainClass
{
	public static int Main(string[] args)
	{
		//오버로딩
		Cat myCat = new Cat("나롱");
		Cat myCat2 = new Cat("다롱", 187);
		
		//상속
		Robot myRobot = new Robot();
		CleanRobot myCleanRobot = new CleanRobot();
		myRobot.Move();
		myCleanRobot.Move();
		//myRobot.Clean();
		myCleanRobot.Clean();

		//접근 제한자
		Human newHuman = new Human("삼식");
		newHuman.SetName("개똥이");
		//Console.WriteLine("이 사람의 이름은 이제 " + newHuman.Name + "입니다.");
		Console.WriteLine("이 사람의 이름은 이제 " + newHuman.GetName() + "입니다.") ;
		return 0;
	}
}
