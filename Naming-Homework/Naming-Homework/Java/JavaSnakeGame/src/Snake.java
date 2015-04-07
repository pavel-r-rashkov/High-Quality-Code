import java.awt.Color;
import java.awt.Graphics;
import java.util.LinkedList;

public class Snake{
	LinkedList<Point> snakeBody = new LinkedList<Point>();
	private Color snakeColor;
	private int velocityX, velocityY;
	
	public Snake() {
		this.snakeColor = Color.GREEN;
		this.snakeBody.add(new To4ka(300, 100)); 
		this.snakeBody.add(new To4ka(280, 100)); 
		this.snakeBody.add(new To4ka(260, 100)); 
		this.snakeBody.add(new To4ka(240, 100)); 
		this.snakeBody.add(new To4ka(220, 100)); 
		this.snakeBody.add(new To4ka(200, 100)); 
		this.snakeBody.add(new To4ka(180, 100));
		this.snakeBody.add(new To4ka(160, 100));
		this.snakeBody.add(new To4ka(140, 100));
		this.snakeBody.add(new To4ka(120, 100));

		velocityX = 20;
		velocityY = 0;
	}
	
	public int getVelocityX() {
		return this.velocityX;
	}

	public void setVelocityX(int velocityX) {
		this.velocityX = velocityX;
	}

	public int getVelocityY() {
		return this.velocityY;
	}

	public void setVelocityY(int velocityY) {
		this.velocityY = velocityY;
	}
	
	public void drawSnake(Graphics g) {		
		for (Point point : this.snakeBody) {
			point.paintPoint(g, this.snakeColor);
		}
	}
	
	public void tick() {
		Point newPosition = new Point((this.snakeBody.get(0).getX() + this.getVelocityX()),
				(this.snakeBody.get(0).getY() + this.getVelocityY));
		
		if (newPosition.getX() > SnakeGame.WIDTH - 20) {
		 	SnakeGame.gameRunning = false;
		} else if (newPosition.getX() < 0) {
			SnakeGame.gameRunning = false;
		} else if (newPosition.getY() < 0) {
			SnakeGame.gameRunning = false;
		} else if (newPosition.getY() > SnakeGame.HEIGHT - 20) {
			SnakeGame.gameRunning = false;
		} else if (SnakeBody.apple.getPoint().equals(newPosition)) {
			this.snakeBody.add(SnakeGame.apple.getPoint());
			SnakeGame.apple = new Apple(this);
			SnakeGame.points += 50;
		} else if (this.snakeBody.contains(newPosition)) {
			SnakeGame.gameRunning = false;
			System.out.println("You ate yourself");
		}	
		
		for (int i = this.snakeBody.size()-1; i > 0; i--) {
			this.snakeBody.set(i, new Point(this.snakeBody.get(i-1)));
		}	
		this.snakeBody.set(0, newPosition);
	}
}
