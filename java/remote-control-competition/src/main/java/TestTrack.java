import java.util.Comparator;
import java.util.List;

public class TestTrack {

    public static void race(RemoteControlCar car) {
        car.drive();
    }

    public static List<ProductionRemoteControlCar> getRankedCars(List<ProductionRemoteControlCar> cars) {
        // Sort by number of victories, most wins first
        cars.sort(Comparator.comparingInt(ProductionRemoteControlCar::getNumberOfVictories));
        return cars.reversed();
    }
}
