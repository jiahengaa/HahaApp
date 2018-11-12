<template>
    <div>{{treeData}}</div>
</template>

<script lang="ts">
import Vue from "vue";
import Component from "vue-class-component";

@Component({
  props: {
    treeData: {
      type: Array,
      default() {
        return [];
      }
    }
  }
})
export default class FileList extends Vue {
  msg: string = "Welcome to Your Vue.js App";

  created() {
    // console.log(`created:${this.name}`)
  }

  // 计算属性
  get computedMsg() {
    return "computed " + this.$props.treeData;
  }

  mounted() {
    // console.log(`mounted:${this.$props.treeData}`)
  }

  getMsg(): string {
    return this.msg;
  }
}
</script>

<style lang="scss">
</style>


