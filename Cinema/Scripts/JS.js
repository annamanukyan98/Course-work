TweenMax.set(container, {
	position: 'absolute',
	top: '140%',
	left: '18%',
	xPercent: -50,
	yPercent: -50
});

TweenMax.set($("#mask"), { scaleX: 0 });

resetAll = function () {
	$("#percentTxt").text("LOADING 0%");
	loadTL.pause(0);
	doneTL.pause(0);
	introTL.play(0);
}

var doneTL = new TimelineMax();
doneTL.pause();

doneTL.add(TweenMax.to($("#film"), 1, { x: 200, ease: Power1.easeIn }), "start");
doneTL.add(TweenMax.to($("#reel"), 1, { rotation: -200, ease: Power1.easeIn }), "start");
doneTL.add(TweenMax.to($("#txtHolder"), 1, { autoAlpha: 0, transformOrigin: "50% 50%", ease: Power1.easeIn }), "start");
doneTL.add(TweenMax.to($("#reel"), .25, { scale: 0, ease: Back.easeIn }), "reel");
doneTL.addCallback(resetAll, "restart+=1");


playDone = function () {
	doneTL.play();
}

updatePercent = function () {
	$("#percentTxt").text("LOADING " + Math.round(loadTL.progress() * 100) + "%");
}

var loadTL = new TimelineMax({ onComplete: playDone });
loadTL.pause();

loadTL.add(TweenMax.to($("#mask"), 5, { scaleX: 1, ease: Power1.easeOut }), "start");
loadTL.add(TweenMax.to($("#reel"), 5, { rotation: 360, transformOrigin: "50% 50%", ease: Power1.easeOut }), "start");
loadTL.add(TweenMax.to($("#reel"), 5, { x: 172, transformOrigin: "50% 50%", ease: Power1.easeOut, onUpdate: updatePercent }), "start");

playLoder = function () {
	loadTL.play();
}

var introTL = new TimelineMax({ onComplete: playLoder });

introTL.add(TweenMax.from($("#reel"), 1, { y: -300, ease: Bounce.easeOut }), "start");
introTL.add(TweenMax.from($("#percentTxt"), 1.5, { autoAlpha: 0, ease: Power1.easeOut }), "start");
