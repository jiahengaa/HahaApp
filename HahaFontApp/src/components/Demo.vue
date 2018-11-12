<template>
    <div>{{msg}}</div>
</template>

<script lang="ts">
import Vue from 'vue'
import Component from 'vue-class-component'

@Component({
  props: {
    propMessage: String
  }
})
export default class SelectCatgory extends Vue {
  msg: string = 'Welcome to Your Vue.js App'

  created() {
    // console.log(`created:${this.name}`)
  }

  // 计算属性
  get computedMsg() {
    return 'computed ' + this.$props.propMessage
  }

  mounted() {
    // console.log(`mounted:${this.name}`)
  }

  getMsg(): string {
    return this.msg
  }
}
</script>

<style lang="scss">
</style>


