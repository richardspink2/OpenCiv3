using C7GameData;
using Xunit;

namespace EngineTests.GameData;

public class MapUnitCombatFacingTest {
	[Fact]
	public void UnitsTurnTowardTargetWhenRotateBeforeAttackIsDisabled() {
		MapUnit unit = MakeUnit(rotateBeforeAttack: false);

		Assert.Equal(TileDirection.EAST, unit.GetAttackAnimationDirection(TileDirection.EAST));
		Assert.Equal(TileDirection.WEST, unit.GetDefenseAnimationDirection(TileDirection.EAST));
	}

	[Fact]
	public void UnitsUseBroadsideFacingWhenRotateBeforeAttackIsEnabled() {
		MapUnit unit = MakeUnit(rotateBeforeAttack: true);

		Assert.Equal(TileDirection.SOUTH, unit.GetAttackAnimationDirection(TileDirection.EAST));
		Assert.Equal(TileDirection.NORTH, unit.GetDefenseAnimationDirection(TileDirection.EAST));
	}

	[Fact]
	public void UnitPrototypePreservesRotateBeforeAttackFromSavedPrototype() {
		UnitPrototype unit = new(new() {
			name = "Galley",
			rotateBeforeAttack = true,
		}, []);

		Assert.True(unit.rotateBeforeAttack);
	}

	private static MapUnit MakeUnit(bool rotateBeforeAttack) {
		return new(ID.None("unit")) {
			unitType = new() {
				rotateBeforeAttack = rotateBeforeAttack,
			}
		};
	}
}
